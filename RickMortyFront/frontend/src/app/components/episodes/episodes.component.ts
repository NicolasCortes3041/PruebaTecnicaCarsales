import { Component, OnInit } from '@angular/core';
import { Episode } from './interfaces/episode';

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

  constructor(private episodeService: EpisodeService) {}

  ngOnInit(): void {
    this.loadEpisodesPage();
  }

  loadEpisodesPage(page: number = 1): void {
    this.episodeService.getEpisodesPagination(page).subscribe((data) => {
      this.episodes = data.results;
      this.currentPage = page;
      this.totalPages = data.info.pages;
    });
  }

  goToPage(page: number) {
    this.loadEpisodesPage(page);
  }

  filtrarTabla(): void {
    const texto = this.searchText.toLowerCase();

    if (texto) {
      this.episodeService.getFilteredEpisode(texto).subscribe((data) => {
        this.episodes = data.results;
        this.totalPages = data.info.pages;
      });
    } else {
      this.loadEpisodesPage();
    }
    console.log(this.episodes);
    console.log(texto);
  }
}
