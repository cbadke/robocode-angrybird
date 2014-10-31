namespace CBad

open Robocode;
open System.Drawing;

type AngryBird() = 
    inherit AdvancedRobot()

    let mutable target = ""

    override r.Run () =
        r.BodyColor <- Color.Black
        r.BulletColor <- Color.Red
        r.RadarColor <- Color.Black
        r.GunColor <- Color.Black
        r.MaxVelocity <- 8.0
        while true do
            r.SetTurnRadarLeft 10000.0
            r.Execute()

    override r.OnScannedRobot e =

            if (not (target.Equals e.Name)) && (not (target.Equals "")) then
                ()
            else
                target <- e.Name
                r.SetAhead ((-) e.Distance 60.0)

                r.SetTurnRight e.Bearing
                if ((<) e.Distance 20.0) then
                    r.SetFire 100.0
                else
                    r.SetFire 5.0
                r.Execute ()
                r.Scan ()

    override r.OnRobotDeath e =
        target <- ""