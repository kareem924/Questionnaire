import { QuestionBase } from './question-base';
export class SectionModel {
  name: string;
  questions: QuestionBase[];

  constructor(section: {
    name?: string;
    questions?: QuestionBase[]
  } = {}) {
    this.name = section.name || '';
    this.questions = section.questions || null;
  }
}
