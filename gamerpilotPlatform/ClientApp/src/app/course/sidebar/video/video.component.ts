import { Component, OnInit, Input } from '@angular/core';
import {SanitizeHtmlPipePipe} from '../../pipes/sanitize-html-pipe.pipe';
import { flyInOut } from '../../../shared/animation';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss'],
  animations: [flyInOut]

})
export class VideoComponent implements OnInit {
 @Input() lecture;
 videos = [];
 selectedVideo;
 hasVideos: boolean;

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
