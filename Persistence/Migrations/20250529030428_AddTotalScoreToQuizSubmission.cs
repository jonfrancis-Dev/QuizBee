using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalScoreToQuizSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_AnswerChoices_SelectedChoiceId",
                table: "SubmittedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_Questions_QuestionId",
                table: "SubmittedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_QuizSubmissions_QuizSubmissionId",
                table: "SubmittedAnswers");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "SubmittedAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedChoiceId",
                table: "SubmittedAnswers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "QuizSubmissionId",
                table: "SubmittedAnswers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionId",
                table: "SubmittedAnswers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "QuizSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnswerSelections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SubmittedAnswerId = table.Column<string>(type: "TEXT", nullable: true),
                    AnswerChoiceId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerSelections_AnswerChoices_AnswerChoiceId",
                        column: x => x.AnswerChoiceId,
                        principalTable: "AnswerChoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerSelections_SubmittedAnswers_SubmittedAnswerId",
                        column: x => x.SubmittedAnswerId,
                        principalTable: "SubmittedAnswers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSelections_AnswerChoiceId",
                table: "AnswerSelections",
                column: "AnswerChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSelections_SubmittedAnswerId",
                table: "AnswerSelections",
                column: "SubmittedAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_AnswerChoices_SelectedChoiceId",
                table: "SubmittedAnswers",
                column: "SelectedChoiceId",
                principalTable: "AnswerChoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_Questions_QuestionId",
                table: "SubmittedAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_QuizSubmissions_QuizSubmissionId",
                table: "SubmittedAnswers",
                column: "QuizSubmissionId",
                principalTable: "QuizSubmissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_AnswerChoices_SelectedChoiceId",
                table: "SubmittedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_Questions_QuestionId",
                table: "SubmittedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_QuizSubmissions_QuizSubmissionId",
                table: "SubmittedAnswers");

            migrationBuilder.DropTable(
                name: "AnswerSelections");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "QuizSubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedChoiceId",
                table: "SubmittedAnswers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuizSubmissionId",
                table: "SubmittedAnswers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionId",
                table: "SubmittedAnswers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "SubmittedAnswers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_AnswerChoices_SelectedChoiceId",
                table: "SubmittedAnswers",
                column: "SelectedChoiceId",
                principalTable: "AnswerChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_Questions_QuestionId",
                table: "SubmittedAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_QuizSubmissions_QuizSubmissionId",
                table: "SubmittedAnswers",
                column: "QuizSubmissionId",
                principalTable: "QuizSubmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
