import { Box, Typography } from '@mui/material';
import type { QuizSubmission } from '../../lib/types';

type Props = {
    result: QuizSubmission;
    email: string;
};

export default function QuizResults({ result, email }: Props) {
    return (
        <Box sx={{ p: 3 }}>
            <Typography variant="h5" gutterBottom>
                Results for {email}
            </Typography>
            <Typography variant="body1" gutterBottom>
                Score: {result.score} / 10
            </Typography>
            <Typography variant="body1" gutterBottom>
                Percentage: {result.percentage}%
            </Typography>
        </Box>

    );
}
