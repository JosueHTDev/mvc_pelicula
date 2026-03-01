import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { PeliculaDto } from '../../models/pelicula/PeliculaDto.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PeliculaService {

  http = inject(HttpClient);

  private apiUrl = 'https://localhost:7000/api/pelicula';

  constructor() { }

  getAll(): Observable<PeliculaDto[]> {
    return this.http.get<PeliculaDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<PeliculaDto> {
    return this.http.get<PeliculaDto>(`${this.apiUrl}/${id}`);
  }

  create(data: PeliculaDto): Observable<PeliculaDto> {
    return this.http.post<PeliculaDto>(this.apiUrl, data);
  }

  update(data: PeliculaDto): Observable<PeliculaDto> {
    // el PUT envía el id en el body
    return this.http.put<PeliculaDto>(this.apiUrl, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}
