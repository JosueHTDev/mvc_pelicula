import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { GeneroPeliculaDto } from '../../models/pelicula/GeneroPeliculaDto.model';
import { catchError, Observable, of } from 'rxjs';

const GENEROS_FALLBACK: GeneroPeliculaDto[] = [
  { id: 1, nombreGenero: 'Acción' },
  { id: 2, nombreGenero: 'Comedia' },
  { id: 3, nombreGenero: 'Drama', },
  { id: 4, nombreGenero: 'Ciencia Ficción' },
  { id: 5, nombreGenero: 'Terror', },
];

@Injectable({
  providedIn: 'root'
})
export class GeneroPeliculaService {

  http = inject(HttpClient);

  private apiUrl = 'https://localhost:7000/api/generoPelicula';

  constructor() { }

  getAll(): Observable<GeneroPeliculaDto[]> {
    return this.http.get<GeneroPeliculaDto[]>(this.apiUrl).pipe(
      catchError(() => {
        console.warn('GeneroPeliculaService: endpoint no disponible, usando géneros locales.');
        return of(GENEROS_FALLBACK);
      })
    );
  }

}