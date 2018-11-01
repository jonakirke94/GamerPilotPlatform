import { Component, OnInit, Input, OnChanges, OnDestroy } from '@angular/core';
import { Video } from '../../../../../models/video';
declare var flowplayer: any;

@Component({
	selector: 'app-flowplayer',
	templateUrl: './flowplayer.component.html',
	styleUrls: ['./flowplayer.component.scss']
})
export class FlowplayerComponent implements OnChanges, OnDestroy {
	@Input() video: Video;
	player: any;
	stopwatch: any;
	rest = 0;
	runTimer = false;
	seconds = 0;
	trackingVideo: Video;

	constructor() { }

	ngOnChanges() {
		if (!this.trackingVideo) {
			this.trackingVideo = this.video;
		}
		this.destroyPlayer();
		this.createPlayer();

	}

	ngOnDestroy() {
		this.destroyPlayer();
	}

	createPlayer() {
		const container = document.getElementById('video-player');
		this.player = flowplayer(container, {
			fullscreen: true,
			share: false,
			title: this.video.name,
			clip: {
					sources: [
							{
									type: 'video/mp4',
									src: this.video.url
							}
					]
			}
		});

		this.player.on('pause', (e, api) => {
			this.stopTimer();
		});

		this.player.on('resume', (e, api) => {
			this.startTimer();
		});
	}

	startTimer() {
		this.stopwatch = setInterval(() => {
			this.seconds++;
		}, 1000);
	}

	stopTimer() {
		clearInterval(this.stopwatch);
		this.stopwatch = null;
	}

	unsubscribe() {
		this.player.off('resume');
		this.player.off('pause');
	}

	destroyPlayer() {
		if (this.player) {

			// only send analytics if the video has been played
			if (this.seconds > 0) {
				const time = this.seconds;
				(<any>window).gtag('event', 'Video', {
					'event_category': 'GP Course Videos',
					'event_action': 'Seconds played',
					'event_label': this.trackingVideo.name,
					'value': time,
				});
			}
			this.stopTimer();
			this.unsubscribe();

			this.seconds = 0;
			this.player.unload();
			this.player.shutdown();

			// after tracking set current video to be tracked;
			this.trackingVideo = this.video;
		}
	}

}
