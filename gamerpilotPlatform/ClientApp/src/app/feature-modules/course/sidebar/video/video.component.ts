import { Component, OnChanges, Input } from '@angular/core';
import { flyInOut } from '../../../../shared/animation';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss'],
  animations: [flyInOut]

})
export class VideoComponent implements OnChanges {
 @Input() lecture;
 videos = [];
 selectedVideo;
 hasVideos: boolean;
 showSmall = false;

 constructor() { }

  ngOnChanges() {
    if (!!this.lecture.videos && this.lecture.videos.length > 0) {
      this.videos = this.lecture.videos;
      this.selectedVideo = this.videos[0];
      this.hasVideos = true;
    }
  }

  selectVideo(video) {
    this.selectedVideo = video;
  }

}
