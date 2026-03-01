import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { PeliculaService } from '../../../services/pelicula/pelicula.service';
import { PeliculaDto } from '../../../models/pelicula/PeliculaDto.model';
import { MantenimientoPeliculaEditarComponent } from '../mantenimiento-pelicula-editar/mantenimiento-pelicula-editar.component';

@Component({
  selector: 'app-mantenimiento-pelicula-list',
  imports: [MantenimientoPeliculaEditarComponent],
  templateUrl: './mantenimiento-pelicula-list.component.html',
  styleUrls: ['./mantenimiento-pelicula-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPeliculaListComponent implements OnInit {

  _peliculaService = inject(PeliculaService);

  peliculas = signal<PeliculaDto[]>([]);
  mostrarModal = false;
  modoEdicion: 'crear' | 'editar' = 'crear';
  peliculaSeleccionada: PeliculaDto | null = null;

  constructor() { }

  ngOnInit() {
    this.getAllPeliculas();
  }

  getAllPeliculas() {
    this._peliculaService.getAll().subscribe({
      next: (data) => {
        console.log('respuesta', data);
        this.peliculas.set(data);
      },
      error: (err) => { console.log('ocurrio un error', err); },
      complete: () => { console.log('getAllPeliculas completed'); }
    });
  }

  abrirAgregar(): void {
    this.modoEdicion = 'crear';
    this.peliculaSeleccionada = null;
    this.mostrarModal = true;
  }

  abrirEditar(pelicula: PeliculaDto): void {
    this.modoEdicion = 'editar';
    this.peliculaSeleccionada = { ...pelicula };
    this.mostrarModal = true;
  }

  cerrarModal(): void {
    this.mostrarModal = false;
    this.peliculaSeleccionada = null;
  }

  onGuardado(): void {
    this.cerrarModal();
    this.getAllPeliculas();
  }

  eliminarPelicula(pelicula: PeliculaDto): void {
    const confirmado = window.confirm(
      `¿Está seguro de eliminar la película "${pelicula.titulo ?? ''}"?`
    );

    if (!confirmado) {
      return;
    }

    this._peliculaService.delete(pelicula.id).subscribe({
      next: () => {
        this.getAllPeliculas();
      },
      error: (err) => {
        console.log('ocurrio un error al eliminar', err);
      },
    });
  }

}
