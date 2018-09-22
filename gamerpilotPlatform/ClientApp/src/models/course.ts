import { Instructor } from './instructor';
import { Lecture } from './lecture';
import { Section } from './section';

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
    sections: Section[];

    constructor() {}
}
