import { questionType } from './question-control.model';

export enum QuestionType {
    TextBox = 1,
    TextArea,
    MultipleChoice,
    CheckBox,
    DropDown,
    FileUpload,
    Date,
    Time,
    LinearScale,
    LinearRate
}

export const questionTypes: questionType[] = [
  { type: QuestionType.TextBox, icon: 'short_text', text: 'Short Ansawers' },
  { type: QuestionType.TextArea, icon: 'notes', text: 'Paragraph' },
  { icon: '', text: '', type: 0 },
  { type: QuestionType.MultipleChoice, icon: 'radio_button_checked', text: 'Multi Choice' },
  { type: QuestionType.CheckBox, icon: 'check_box', text: 'CheckBox' },
  { type: QuestionType.DropDown, icon: 'arrow_drop_down_circle', text: 'DropDown' },
  { icon: '', text: '', type: 0 },
  { type: QuestionType.LinearScale, icon: 'linear_scale', text: 'Linear Scale' },
  { type: QuestionType.LinearRate, icon: 'star_rate', text: 'Rate Scale' },
  { icon: '', text: '', type: 0 },
  { type: QuestionType.Date, icon: 'event', text: 'Date' },
  { type: QuestionType.Time, icon: 'schedule', text: 'Time' }];
