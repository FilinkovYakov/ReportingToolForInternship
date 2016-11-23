function ReportVM(mentorName, internName, type, date, activities, futurePlans) {
    this.MentorName = mentorName;
    this.InternName = internName;
    this.Type = type;
    this.Date = date;
    this.Activities = activities;
    this.FuturePlans = futurePlans;
}

function FuturePlanVM(description) {
    this.Description = description;
}

function ActivityVM(description, evaluation, questions) {
    this.Description = description;
    this.Evaluation = evaluation;
    this.Questions = questions;
}

function QuestionVM(description) {
    this.Description = description;
}