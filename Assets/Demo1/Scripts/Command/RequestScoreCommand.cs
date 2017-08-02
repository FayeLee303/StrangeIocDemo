using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class RequestScoreCommand : Command {

    [Inject]
    public IScoreService scoreService { get; set; }

    //在mediator里触发
    public override void Execute() {
        scoreService.RequestScore("http://xxxxxxx");
    }
}
