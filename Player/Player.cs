using System;
using Godot;

[Tool]
public class Player : RigidBody2D {
    #region Variables

    private RayCast2D groundCheck;
    private RayCast2D wallCheckL;
    private RayCast2D wallCheckR;

    private float radius = 10f;
    [Export] public float Radius {
        get { return radius; }
        set {
            // Update the value and drawing
            radius = value;
            Update ();

            // Set collision shape size
            CollisionShape2D myCol = GetNode<CollisionShape2D> ("Collision");
            if (myCol != null) {
                Shape2D myColShape = myCol.GetShape ();
                if (myColShape != null) {
                    myColShape.Set ("radius", radius);
                    myColShape.Dispose ();
                }
                myCol.Dispose ();
            }

            // Update the ground check distance
            if (groundCheck != null) {
                groundCheck.SetCastTo (new Vector2 (0, radius * 1.1f));
                groundCheck.Dispose ();
            }

            // Update the left wall check distance
            if (wallCheckL != null) {
                wallCheckL.SetCastTo (new Vector2 (-(radius * 1.1f), 0));
                wallCheckL.Dispose ();
            }

            // Update the right wall check distance
            if (wallCheckR != null) {
                wallCheckR.SetCastTo (new Vector2 ((radius * 1.1f), 0));
                wallCheckR.Dispose ();
            }
        }
    }
    private Color color = Colors.White;

    [Export] public Color MyColor {
        get { return color; }
        set {
            color = value;
            Update ();
        }
    }

    // private float speed = 10f;
    // private float jumpForce = 10f;
    // private float health = 3f;
    // private float lives = 3f;

    #endregion

    public override void _Init () {
        // Get the nodes for raycasting
        groundCheck = GetNode<RayCast2D> ("GroundCheck");
        wallCheckL = GetNode<RayCast2D> ("WallCheckL");
        wallCheckR = GetNode<RayCast2D> ("WallCheckR");
        // Force a single update
        Radius = radius;
    }

    public override void _Process(float delta) {
        // Input and state logic should go here
    }

    public override void _PhysicsProcess(float delta) {
        // Physics logic goes here
    }

    public override void _Draw () {
        // Draw a circle -- current player graphic
        DrawCircle (new Vector2 (0, 0), radius, color);
    }
}
