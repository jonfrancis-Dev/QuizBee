import { useState } from "react";
import { useQuiz } from "../../lib/hooks/useQuiz";
import QuizCard from "./QuizCard";
import QuizNav from "./QuizNav";
import { Container, Typography, Box } from "@mui/material";

export default function QuizPage() {
  const { data: questions, isLoading } = useQuiz();
  const [step, setStep] = useState(0);
  const [answers, setAnswers] = useState<Record<string, string>>({});

  if (isLoading) return <Typography>Loading...</Typography>;
  if (!questions) return null;

  const current = questions[step];

  const handleSelect = (choiceId: string) => {
    setAnswers((prev) => ({ ...prev, [current.id]: choiceId }));
  };

  return (
    <Container maxWidth="sm">
      <Box mt={4}>
        <Typography variant="h4" align="center" gutterBottom>
          QuizBee 🐝
        </Typography>

        <QuizCard
          question={current}
          index={step}
          selectedChoiceId={answers[current.id]}
          onSelect={handleSelect}
        />

        <QuizNav
          step={step}
          total={questions.length}
          onNext={() => setStep((s) => s + 1)}
          onBack={() => setStep((s) => s - 1)}
          disableNext={!answers[current.id]}
        />
      </Box>
    </Container>
  );
}
