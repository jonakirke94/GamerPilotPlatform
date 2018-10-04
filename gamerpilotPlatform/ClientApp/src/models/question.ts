import { Choice } from './choice';

export interface Question {
    questionText: string;
    difficulty: string;
    choices: Choice[];
}
