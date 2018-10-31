import { Component, OnInit, Input, OnChanges, OnDestroy } from '@angular/core';
declare var flowplayer: any;

@Component({
	selector: 'app-flowplayer',
	templateUrl: './flowplayer.component.html',
	styleUrls: ['./flowplayer.component.scss']
})
export class FlowplayerComponent implements OnChanges, OnDestroy {
	@Input() video;
	player: any;
	stopwatch: any;
	rest = 0;
	runTimer = false;
	seconds = 0;

	constructor() { }

	ngOnChanges() {
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

	success() {
		console.log('was successfully tracked');
	}

	destroyPlayer() {

		if (this.player) {
			(<any>window).gtag('event', 'Video', {
				'event_category': 'Videos',
				'event_action': 'Seconds played',
				'event_label': this.video.name,
				'value': this.seconds,
				'event_callback': this.success()
			});
			clearInterval(this.stopwatch);
			this.seconds = 0;
			this.player.unload();
			this.player.shutdown();
		}
	}

}
