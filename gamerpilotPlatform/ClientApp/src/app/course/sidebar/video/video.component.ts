import { Component, OnInit, Input } from '@angular/core';
import {SanitizeHtmlPipePipe} from '../../pipes/sanitize-html-pipe.pipe';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {
 @Input() lecture;
 videos = [];
 private selectedVideo;
 private hasVideos: boolean;

 constructor() { }

  ngOnInit() {
    console.log(this.lecture);
    if (!!this.lecture.videos && this.lecture.videos.length > 0) {
      this.videos = this.lecture.videos;
      this.selectedVideo = this.videos[0];
      this.hasVideos = true;
    }
  }

  selectVideo(video) {
    console.log('selected', video);
    this.selectedVideo = video;
  }

}
