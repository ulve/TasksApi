namespace TasksApi.Db

open System.Collections.Generic

type Team = Frontend | Backend | Test
type Stage = Utveckling | Test | Merge
type Task = {Id:int; AssignedTeam:Team; Story:string; Description:string; InStage:Stage; NeedsRebase:bool; DependsOn:Task list}

module Db = 
    let private tasksStorage = new Dictionary<int, Task>()
    tasksStorage.Add(0,{Id = 0;AssignedTeam = Frontend; Story = "SARA-1789"; Description = "En kort beskrivning"; InStage = Utveckling; NeedsRebase = false; DependsOn = []})
    

    let getTasks () = 
        tasksStorage.Values |> Seq.map(fun t -> t)

    let createTask task =
        let id = tasksStorage.Values.Count + 1
        let newTask = {
            Id = id
            AssignedTeam = task.AssignedTeam
            Story = task.Story
            Description = task.Description
            InStage = task.InStage
            NeedsRebase = task.NeedsRebase
            DependsOn = task.DependsOn
        }
        tasksStorage.Add(id, newTask)
        newTask

    let updateTaskById taskId replacementTask =
        if tasksStorage.ContainsKey(taskId) then
            let updatedTask = {
                Id = taskId
                AssignedTeam = replacementTask.AssignedTeam
                Story = replacementTask.Story
                Description = replacementTask.Description
                InStage = replacementTask.InStage
                NeedsRebase = replacementTask.NeedsRebase
                DependsOn = replacementTask.DependsOn
            }
            tasksStorage.[taskId] <- updatedTask
            Some updatedTask
        else
            None

    let updateTask replacementTask = 
        updateTaskById replacementTask.Id replacementTask

    let deleteTask taskId =
        tasksStorage.Remove(taskId) |> ignore

    let getTask taskId = 
        if tasksStorage.ContainsKey(taskId) then
            Some tasksStorage.[taskId]
        else
            None
    
    let isTaskExists = tasksStorage.ContainsKey

 


