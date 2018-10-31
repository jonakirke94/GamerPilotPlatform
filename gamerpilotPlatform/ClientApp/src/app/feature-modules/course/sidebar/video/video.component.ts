import { Component, OnChanges, Input, OnInit } from '@angular/core';
import { flyInOut } from '../../../../shared/animation';
import { FlowplayerComponent } from '../flowplayer/flowplayer.component';
import { Video } from 'src/models/video';


@Component({
	selector: 'app-video',
	templateUrl: './video.component.html',
	styleUrls: ['./video.component.scss'],
	animations: [flyInOut]
})
export class VideoComponent implements OnChanges {
	@Input() lecture;
	videos: Video[] = [];
	selectedVideo: Video;
	hasVideos: boolean;
	showSmall = false;

 constructor() {
	}

ngOnChanges() {
		if (!!this.lecture.videos && this.lecture.videos.length > 0) {
			this.videos = this.lecture.videos as Video[];
			this.selectedVideo = this.videos[0];
			this.hasVideos = true;
		}
	}

	selectVideo(video) {
		this.selectedVideo = video;
	}
}


