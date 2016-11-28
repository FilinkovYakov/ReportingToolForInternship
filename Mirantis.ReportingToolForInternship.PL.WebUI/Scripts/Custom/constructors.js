function ReportVM(id, mentorName, internName, typeOccuring, date, activities, futurePlans) {
    this.Id = id,
    this.MentorName = mentorName;
    this.InternName = internName;
    this.TypeOccuring = typeOccuring;
    this.Date = date;
    this.Activities = activities;
    this.FuturePlans = futurePlans;
}

function FuturePlanVM(id, description) {
    this.Id = id;
    this.Description = description;
}

function ActivityVM(id, description, evaluation, questions) {
    this.Id = id;
    this.Description = description;
    this.Evaluation = evaluation;
    this.Questions = questions;
}

function QuestionVM(id, description) {
    this.Id = id;
    this.Description = description;
}