export interface Question {
  id: string;
  text: string;
  hint?: string;
  choices: AnswerChoice[];
}

export interface AnswerChoice {
  id: string;
  text: string;
  isCorrect: boolean;
  questionId: string;
}

export interface QuizSubmission {
  id: string;
  userEmail: string;
  submittedAt: string;
  totalScore: number;
  percentage: number;
  submittedAnswers: SubmittedAnswer[];
}

export interface SubmittedAnswer {
  id: string;
  questionId: string;
  selectedChoiceId: string;
}