import { QuestionType } from './question-type.enum';
export class QuestionBase {
  value: any;
  key: string;
  label: string;
  required: boolean;
  order: number;
  controlType: QuestionType;
  type: string;
  options: { key: string, value: string }[];

  constructor(options: {
    value?: any;
    key?: string;
    label?: string;
    required?: boolean;
    order?: number;
    controlType?: QuestionType;
    type?: string;
    options?: { key: string, value: string }[];
  } = {}) {
    this.value = options.value || '';
    this.key = options.key || '';
    this.label = options.label || '';
    this.required = !!options.required;
    this.order = options.order === undefined ? 1 : options.order;
    this.controlType = options.controlType || null;
    this.type = options.type || '';
    this.options = options.options || [];
  }
}
