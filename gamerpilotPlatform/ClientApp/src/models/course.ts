import { Instructor } from './instructor';
import { Lecture } from './lecture';
import { Section } from './section';

export interface Course {
    id: string;
    description: string;
    imageUrl: string;
    isReleased: boolean;
    name: string;
    urlName: string;
    instructors: Instructor[];
    lectures: any[];
    sections: Section[];
    completedLectures: number[];
}
