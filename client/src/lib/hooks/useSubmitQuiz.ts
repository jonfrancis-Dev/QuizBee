import { useMutation } from '@tanstack/react-query';
import agent from '../api/agent';
import type { SubmitPayload, QuizSubmission } from '../types';

export const useSubmitQuiz = () => {
  return useMutation<QuizSubmission, unknown, SubmitPayload>({
    mutationFn: async (data) => {
      const response = await agent.post('/quiz/submit', data);
      return response.data;
    }
  });
};
