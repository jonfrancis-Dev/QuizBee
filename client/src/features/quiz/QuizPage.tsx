import { useState } from "react";
import { useQuiz } from "../../lib/hooks/useQuiz";
import QuizCard from "./QuizCard";
import QuizNav from "./QuizNav";
import { Container, Typography, Box, Alert, TextField, Button, CircularProgress } from "@mui/material";
import QuizResults from "./QuizResults";
import { useSubmitQuiz } from "../../lib/hooks/useSubmitQuiz";
import { isAxiosError } from "axios";

export default function QuizPage() {
  const { data: questions, isLoading } = useQuiz();
  const { mutate, data: result, isPending, isError, error } = useSubmitQuiz();

  const [email, setEmail] = useState('');
  const [step, setStep] = useState(0);
  const [answers, setAnswers] = useState<Record<string, string>>({});
  const [showResults, setShowResults] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");
  const [hintShown, setHintShown] = useState<Record<string, boolean>>({});


  if (isLoading) return <Typography>Loading questions...</Typography>;
  if (!questions) return null;

  const current = questions[step];
  const isHintShown = hintShown[current.id] || false; // So the hint can be toggled back on after next button

  const handleShowHint = () => {
    setHintShown(prev => ({ ...prev, [current.id]: true }));
  };

  const handleSelect = (choiceId: string) => {
    setAnswers((prev) => ({ ...prev, [current.id]: choiceId }));
  };

  const handleSubmit = () => {
    if (!email || Object.keys(answers).length < 10) { // Had to use Object.keys because answers is an object
      setErrorMessage("Please enter your email and answer all questions.");
      return;
    }

    mutate(
      {
        userEmail: email,
        answers: Object.entries(answers).map(([questionId, selectedChoiceId]) => ({
          questionId,
          selectedChoiceId,
        })),
      },
      {
        onSuccess: () => setShowResults(true),
      }
    );
  };


  if (showResults && result) {
    return (
      <QuizResults
        result={result}
        email={email}
      />
    );
  }
  return (

    <Container maxWidth="sm">
      <Box mt={4}>
        <Typography variant="h4" align="center" gutterBottom>
          QuizBee 🐝
        </Typography>

        {errorMessage && (
          <Alert severity="error" sx={{ mb: 2 }}>
            {errorMessage}
          </Alert>
        )}

        <TextField
          fullWidth
          label="Enter your email"
          variant="outlined"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          sx={{ mb: 3 }}
        />

        <QuizCard
          question={current}
          index={step}
          selectedChoiceId={answers[current.id]}
          onSelect={handleSelect}
          showHint={isHintShown}
          onShowHint={handleShowHint}
        />

        <QuizNav
          step={step}
          total={questions.length}
          onNext={() => setStep((s) => s + 1)}
          onBack={() => setStep((s) => s - 1)}
          disableNext={!answers[current.id]}
        />
        {step === questions.length - 1 && (
          <Box textAlign="center" mt={3}>
            <Button
              variant="contained"
              color="primary"
              onClick={handleSubmit}
              disabled={isPending}
            >
              {isPending ? <CircularProgress size={24} /> : "Submit Quiz"}
            </Button>
          </Box>
        )}

        {isError && isAxiosError(error) && (
          <Alert severity="error">
            {error.response?.data?.message || 'Submission failed.'}
          </Alert>)}
      </Box>
    </Container>
  );
}
