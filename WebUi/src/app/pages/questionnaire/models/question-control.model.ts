export interface questionType {
  type: number;
  icon: string;
  text: string;
}

export class QuestionControl {
  selectedType: questionType;
  isRequired: boolean;
  label: string;
  options: OptionsValue[] = [{ optionValue: 'Option 1' }];
  rateValue: RatingValue = { from: 0, to: 2, fromLabel: '', toLabel: '' };
  isEdit: boolean;
}

export interface OptionsValue {
  optionValue: string;
}

export interface RatingValue {
  from: number;
  to: number;
  fromLabel: string;
  toLabel: string;
}
