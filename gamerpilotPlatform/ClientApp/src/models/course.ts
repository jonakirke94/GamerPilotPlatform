import { Instructor } from './instructor';
import { Lecture } from './lecture';

export class Course {
    id: string;
    courseLength: string;
    imageUrl: string;
    language: string;
    level: string;
    lifeSkill: string;
    name: Date;
    urlName: Date;
    instructors: Instructor[];
    lectures: Lecture[];

    constructor() {}
}
