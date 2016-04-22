// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Suave.Web
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.WebPart
open Suave.Utils.Choice
open TasksApi.Db
open TasksApi.Rest


[<EntryPoint>]
let main _ =    
    let tasksWebPart = rest "tasks" {
        GetAll = Db.getTasks
        Create = Db.createTask
        Update = Db.updateTask
        Delete = Db.deleteTask        
        GetById = Db.getTask
        UpdateById = Db.updateTaskById
        IsExists = Db.isTaskExists
    }

    startWebServer defaultConfig tasksWebPart
    0 // return an integer exit code



