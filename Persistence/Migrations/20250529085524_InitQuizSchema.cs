using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitQuizSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Hint = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizSubmissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSubmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerChoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<string>(type: "TEXT", nullable: true),
                    QuizSubmissionId = table.Column<string>(type: "TEXT", nullable: true),
                    SelectedChoiceId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedAnswers_AnswerChoices_SelectedChoiceId",
                        column: x => x.SelectedChoiceId,
                        principalTable: "AnswerChoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubmittedAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubmittedAnswers_QuizSubmissions_QuizSubmissionId",
                        column: x => x.QuizSubmissionId,
                        principalTable: "QuizSubmissions",
                        principalColumn: "Id");
                });

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
                name: "IX_AnswerChoices_QuestionId",
                table: "AnswerChoices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSelections_AnswerChoiceId",
                table: "AnswerSelections",
                column: "AnswerChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSelections_SubmittedAnswerId",
                table: "AnswerSelections",
                column: "SubmittedAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_QuestionId",
                table: "SubmittedAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_QuizSubmissionId",
                table: "SubmittedAnswers",
                column: "QuizSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_SelectedChoiceId",
                table: "SubmittedAnswers",
                column: "SelectedChoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerSelections");

            migrationBuilder.DropTable(
                name: "SubmittedAnswers");

            migrationBuilder.DropTable(
                name: "AnswerChoices");

            migrationBuilder.DropTable(
                name: "QuizSubmissions");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
