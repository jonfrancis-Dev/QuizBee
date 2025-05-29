import { Box, Button } from "@mui/material";

type Props = {
  step: number;
  total: number;
  onNext: () => void;
  onBack: () => void;
  disableNext?: boolean;
};

export default function QuizNav({ step, total, onNext, onBack, disableNext }: Props) {
const isLastStep = step === total - 1;

  return (
    <Box display="flex" justifyContent="space-between" mt={2}>
      <Button variant="outlined" onClick={onBack} disabled={step === 0}>
        Back
      </Button>
      {!isLastStep && (
        <Button variant="contained" onClick={onNext} disabled={disableNext}>
          Next
        </Button>
      )}
    </Box>
  );
}
