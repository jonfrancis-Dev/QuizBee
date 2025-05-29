import { Box, Typography } from '@mui/material';
import type { AnswerSubmissionDto, QuizSubmission } from '../../lib/types';

type Props = {
    answers: AnswerSubmissionDto[];
    result: QuizSubmission;
    email: string;
};

export default function QuizResults({ answers, result, email }: Props) {
    return (
        <Box sx={{ p: 3 }}>
            <Typography variant="h5" gutterBottom>
                Results for {email}
            </Typography>
            <Typography variant="body1" gutterBottom>
                Score: {result.score} / {answers.length - 1}
            </Typography>
            <Typography variant="body1" gutterBottom>
                Percentage: {result.percentage}%
            </Typography>
        </Box>

    );
}
