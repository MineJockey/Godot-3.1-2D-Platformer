using System;
using Godot;

public class Platform : KinematicBody2D {
    #region Variables

    private Vector2 size;
    [Export] public Vector2 Size {
        get { return size; }
        set {
            
        }
    }

    #endregion
}
