function ReportVM(id, title, taskId, managerId, engineerId, date, activities, futurePlans) {
    this.Id = id;
	this.Title = title;
	this.TaskId = taskId;
	this.ManagerId = managerId;
	this.EngineerId = engineerId;
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