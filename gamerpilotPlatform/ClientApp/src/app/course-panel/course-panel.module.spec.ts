import { CoursePanelModule } from './course-panel.module';

describe('CoursePanelModule', () => {
  let coursePanelModule: CoursePanelModule;

  beforeEach(() => {
    coursePanelModule = new CoursePanelModule();
  });

  it('should create an instance', () => {
    expect(coursePanelModule).toBeTruthy();
  });
});
