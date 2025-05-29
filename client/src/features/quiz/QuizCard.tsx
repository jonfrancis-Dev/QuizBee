import { Card, CardContent, Typography, List, ListItem, ListItemButton } from "@mui/material";
import type { Question } from "../../lib/types";

type Props = {
  index: number;
  question: Question;
  selectedChoiceId?: string;
  onSelect: (choiceId: string) => void;
};

export default function QuizCard({ index, question, selectedChoiceId, onSelect }: Props) {
  return (
    <Card sx={{ my: 2 }}>
      <CardContent>
        <Typography variant="h6" gutterBottom>
          {index + 1}. {question.text}
        </Typography>
        {question.hint && (
          <Typography variant="body2" color="text.secondary" sx={{ mb: 2 }}>
            Hint: {question.hint}
          </Typography>
        )}
        <List>
          {question.choices.map((choice) => (
            <ListItem key={choice.id} disablePadding>
              <ListItemButton
                selected={selectedChoiceId === choice.id}
                onClick={() => onSelect(choice.id)}
              >
                {choice.text}
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </CardContent>
    </Card>
  );
}
