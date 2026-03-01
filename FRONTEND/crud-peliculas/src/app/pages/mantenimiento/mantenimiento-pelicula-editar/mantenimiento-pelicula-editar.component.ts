import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  effect,
  inject,
  input,
  OnInit,
  output,
  signal,
} from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PeliculaDto } from '../../../models/pelicula/PeliculaDto.model';
import { GeneroPeliculaDto } from '../../../models/pelicula/GeneroPeliculaDto.model';
import { PeliculaService } from '../../../services/pelicula/pelicula.service';
import { GeneroPeliculaService } from '../../../services/pelicula/genero-pelicula.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mantenimiento-pelicula-editar',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './mantenimiento-pelicula-editar.component.html',
  styleUrls: ['./mantenimiento-pelicula-editar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPeliculaEditarComponent implements OnInit {

  // VARIABLES DE ENTRADA DESDE EL COMPONENTE PADRE (LIST)
  pelicula = input<PeliculaDto | null>(null);
  modo = input<'crear' | 'editar'>('crear');

  // VARIABLES DE SALIDA HACIA EL COMPONENTE PADRE (LIST)
  cancelado = output<void>();
  guardado = output<void>();

  // INYECCIÓN DE SERVICIOS
  private readonly peliculaService = inject(PeliculaService);
  private readonly generoPeliculaService = inject(GeneroPeliculaService);
  private readonly formBuilder = inject(FormBuilder);
  private readonly cdr = inject(ChangeDetectorRef);

  // SIGNAL PARA LOS GÉNEROS
  generos = signal<GeneroPeliculaDto[]>([]);

  // FORMULARIO REACTIVO
  readonly form = this.formBuilder.group({
    titulo:           ['', [Validators.required]],
    director:         ['', [Validators.required]],
    anioEstreno:      [new Date().getFullYear(), [Validators.required, Validators.min(1888), Validators.max(2100)]],
    duracionMinutos:  [0,  [Validators.required, Validators.min(1)]],
    idGeneroPelicula: [0,  [Validators.required, Validators.min(1)]],
  });

  cargando = false;

  constructor() {
    // EFECTO: cuando cambia la película de entrada, se actualiza el formulario
    effect(() => {
      const pelicula = this.pelicula();
      this.form.reset({
        titulo:           pelicula?.titulo           ?? '',
        director:         pelicula?.director         ?? '',
        anioEstreno:      pelicula?.anioEstreno      ?? new Date().getFullYear(),
        duracionMinutos:  pelicula?.duracionMinutos  ?? 0,
        idGeneroPelicula: pelicula?.idGeneroPelicula ?? 0,
      });
      // Forzar detección de cambios para que OnPush pinte el valor seleccionado
      this.cdr.markForCheck();
    });
  }

  ngOnInit(): void {
    this.cargarGeneros();
  }

  cargarGeneros(): void {
    this.generoPeliculaService.getAll().subscribe({
      next: (data) => {
        this.generos.set(data);
        this.cdr.markForCheck();
      },
      error: (err) => {
        console.error('Error al cargar géneros:', err);
        this.generos.set([
          { id: 1, nombreGenero: 'Acción' },
          { id: 2, nombreGenero: 'Comedia' },
          { id: 3, nombreGenero: 'Drama' },
          { id: 4, nombreGenero: 'Terror' },
          { id: 5, nombreGenero: 'Ciencia Ficción' },
        ]);
        this.cdr.markForCheck();
      },
    });
  }

  onCancelar(): void {
    this.cancelado.emit();
  }

  onGuardar(): void {
    this.form.markAllAsTouched();
    if (this.form.invalid || this.cargando) {
      return;
    }

    this.cargando = true;

    const valores = this.form.getRawValue();
    const actual  = this.pelicula();

    const payload: PeliculaDto = {
      id:               actual?.id ?? 0,
      idGeneroPelicula: valores.idGeneroPelicula ?? 0,
      titulo:           valores.titulo,
      director:         valores.director,
      anioEstreno:      valores.anioEstreno      ?? 0,
      duracionMinutos:  valores.duracionMinutos  ?? 0,
    };

    const request$ = this.modo() === 'editar' && payload.id > 0
      ? this.peliculaService.update(payload)
      : this.peliculaService.create(payload);

    request$.subscribe({
      next: () => {
        this.guardado.emit();
      },
      error: (error) => {
        console.error('Error al guardar película', error);
        this.cargando = false;
        this.cdr.markForCheck();
      },
      complete: () => {
        this.cargando = false;
        this.cdr.markForCheck();
      },
    });
  }
}