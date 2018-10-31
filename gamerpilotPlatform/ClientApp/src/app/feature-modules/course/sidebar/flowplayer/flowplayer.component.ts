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
			clearInterval(this.stopwatch);
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

	destroyPlayer() {
		if (this.player) {
			(<any>window).gtag('event', 'Video', {
				'event_category': 'GamerPilot Videos',
				'event_action': 'Seconds played',
				'event_label': this.video.name,
				'value': this.seconds,
			});
			clearInterval(this.stopwatch);
			this.seconds = 0;
			this.player.unload();
			this.player.shutdown();

			// after tracking set current video to be tracked;
			this.trackingVideo = this.video;
		}
	}

}
