import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EpisodeResponse } from '../components/episodes/interfaces/espisodeResponse';
import { Observable } from 'rxjs';
import { environment } from '../../../environment';

@Injectable({
  providedIn: 'root',
})
export class EpisodeService {
  private baseUrl = 'http://localhost:5078/api/Episode';

  constructor(private http: HttpClient) {}

  getEpisodesPagination(page: number): Observable<EpisodeResponse> {
    return this.http.get<EpisodeResponse>(`${this.baseUrl}/page?page=${page}`);
  }

  getFilteredEpisode(name: string): Observable<EpisodeResponse> {
    return this.http.get<EpisodeResponse>(`${environment.baseUrl}/filter?name=${name}`);
  }
}
