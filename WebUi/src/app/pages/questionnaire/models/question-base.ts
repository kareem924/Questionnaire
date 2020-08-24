import { QuestionType } from './question-type.enum';
export class QuestionBase {
  value: any;
  key: string;
  label: string;
  required: boolean;
  order: number;
  controlType: QuestionType;
  type: string;
  ratingValue: RatingValue;
  options: { key: string, value: string, checked: boolean }[];

  constructor(options: {
    value?: any;
    key?: string;
    label?: string;
    required?: boolean;
    order?: number;
    controlType?: QuestionType;
    type?: string;
    ratingValue?: RatingValue;
    options?: { key: string, value: string, checked: boolean }[];
  } = {}) {
    this.value = options.value || '';
    this.key = options.key || '';
    this.label = options.label || '';
    this.required = !!options.required;
    this.order = options.order === undefined ? 1 : options.order;
    this.controlType = options.controlType || null;
    this.type = options.type || '';
    this.ratingValue = options.ratingValue || null;
    this.options = options.options || [];
  }
}

export class RatingValue {
  from: number;
  to: number;
  fromLabel: string;
  toLabel: string;
  constructor(value: {
    from?: number;
    to?: number;
    fromLabel?: string;
    toLabel?: string
  } = {}) {
    this.from = value.from;
    this.to = value.to;
    this.fromLabel = value.fromLabel || '';
    this.toLabel = value.toLabel || '';
  }
}
