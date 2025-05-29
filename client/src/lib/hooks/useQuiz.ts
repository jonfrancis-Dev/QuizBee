// src/hooks/useQuiz.ts
import { useQuery } from '@tanstack/react-query';
import agent from '../api/agent';
import type { Question } from '../types';

export const useQuiz = () => {
  return useQuery<Question[]>({
    queryKey: ['quiz'],
    queryFn: async () => {
      const response = await agent.get<Question[]>('/quiz');
      return response.data;
    }
  });
};