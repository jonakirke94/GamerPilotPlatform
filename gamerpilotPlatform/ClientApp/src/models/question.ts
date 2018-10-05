import { Choice } from './quiz/choice';

export interface Question {
    questionText: string;
    difficulty: string;
    choices: Choice[];
}
