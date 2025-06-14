import { Component, OnInit } from '@angular/core';
import { Episode } from './interfaces/episode';
import Swal from 'sweetalert2';

import { CommonModule } from '@angular/common';
import { EpisodeService } from '../../service/episode.service';
import { PaginationComponent } from '../pagination/pagination.component';
import { DateFnsFormatPipe } from '../../pipes/date-fns-format.pipe';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-episodes',
  standalone: true,
  imports: [CommonModule, FormsModule, PaginationComponent, DateFnsFormatPipe],
  templateUrl: './episodes.component.html',
  styleUrl: './episodes.component.css',
})
export class EpisodesComponent implements OnInit {
  episodes: Episode[] = [];
  currentPage = 1;
  totalPages = 1;
  searchText: string = '';
  aboveSearchText: string = '';

  constructor(private episodeService: EpisodeService) {}

  ngOnInit(): void {
    this.loadEpisodesPage();
  }

  loadEpisodesPage(page: number = 1): void {
    this.episodeService.getEpisodesPagination(page).subscribe({
      next: (data) => {
        this.episodes = data.results;
        this.currentPage = page;
        this.totalPages = data.info.pages;
      },
      error: (error) => {
        Swal.fire(error.error.msg, '', 'error');
        this.episodes = [];
        this.totalPages = 1;
      },
    });
  }

  goToPage(page: number) {
    this.loadEpisodesPage(page);
  }

  filtrarTabla(event: Event): void {
    const valorActual = (event.target as HTMLInputElement).value;
    const texto = this.searchText.toLowerCase();

    let deleteText: boolean = false;

    if (valorActual.length < this.aboveSearchText.length) {
      deleteText = true;
    } else {
      deleteText = false;
    }

    if (texto) {
      this.episodeService.getFilteredEpisode(texto).subscribe({
        next: (data) => {
          this.episodes = data.results;
          this.totalPages = data.info.pages;
        },
        error: (error) => {
          if (!deleteText) {
            Swal.fire(error.error.msg, '', 'error');
            this.episodes = [];
            this.totalPages = 1;
          }
        },
      });
    } else {
      this.loadEpisodesPage();
    }

    this.aboveSearchText = valorActual;
  }
}
