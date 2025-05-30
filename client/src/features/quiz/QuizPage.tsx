import { useState } from "react";
import { useQuiz } from "../../lib/hooks/useQuiz";
import QuizCard from "./QuizCard";
import QuizNav from "./QuizNav";
import { Container, Typography, Box, Alert, TextField, Button, CircularProgress } from "@mui/material";
import QuizResults from "./QuizResults";
import { useSubmitQuiz } from "../../lib/hooks/useSubmitQuiz";
import { isAxiosError } from "axios";
import isValidEmail from "../../lib/utils/EmailValidator";
import { Bolt } from "@mui/icons-material";

export default function QuizPage() {
  const { data: questions, isLoading } = useQuiz();
  const { mutate, data: result, isPending, isError, error } = useSubmitQuiz();

  const [email, setEmail] = useState('');
  const [step, setStep] = useState(0);
  const [answers, setAnswers] = useState<Record<string, string[]>>({});
  const [showResults, setShowResults] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");
  const [hintShown, setHintShown] = useState<Record<string, boolean>>({});

  if (isLoading) return <Typography>Loading questions...</Typography>;
  if (!questions) return null;

  const current = questions[step];
  const isHintShown = hintShown[current.id] || false;

  const handleShowHint = () => {
    setHintShown(prev => ({ ...prev, [current.id]: true }));
  };

  const handleSelect = (choiceId: string) => {
    const currentAnswers = answers[current.id] || [];

    const updatedAnswers = currentAnswers.includes(choiceId)
      ? currentAnswers.filter(id => id !== choiceId)
      : [...currentAnswers, choiceId];

    setAnswers(prev => ({
      ...prev,
      [current.id]: updatedAnswers
    }));
  };

  const handleSubmit = () => {

    if (!isValidEmail(email)) {
      setErrorMessage("Please enter a valid email address.");
      return;
    }

    if (Object.keys(answers).length < 10) {
      setErrorMessage("Please answer all questions before submitting.");
      return;
    }

    mutate(
      {
        userEmail: email,
        answers: Object.entries(answers).map(([questionId, selectedChoiceIds]) => ({
          questionId,
          selectedChoiceIds,
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
        <Box display='flex' sx={{justifyContent:'center'}}>
          <Typography variant="h4" align="center" gutterBottom color="#182a73">
            QuizBee
          </Typography>
          <Bolt fontSize="large" sx={{color:"#182a73"}} />
        </Box>


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
          onChange={(e) => {
            setEmail(e.target.value);
            if (errorMessage) setErrorMessage(""); // Clear error as user types
          }}
          sx={{ mb: 3 }}
          error={!!errorMessage}
        />

        <QuizCard
          question={current}
          index={step}
          selectedChoiceIds={answers[current.id] || []}
          onSelect={handleSelect}
          showHint={isHintShown}
          onShowHint={handleShowHint}
        />

        <QuizNav
          step={step}
          total={questions.length}
          onNext={() => setStep((s) => s + 1)}
          onBack={() => setStep((s) => s - 1)}
          disableNext={!answers[current.id]?.length}
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
          </Alert>
        )}
      </Box>
    </Container>
  );
}
