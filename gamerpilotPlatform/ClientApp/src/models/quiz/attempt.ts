import { Answer } from './answer';

export interface Attempt {
    id: number;
    answers: Answer[];
    submissionTime: Date;
}
