using UnityEngine;
using Anomaly;

public class Player : Actor
{
    [SerializeField, HideInInspector]
    private PhysicsComponent physics = new PhysicsComponent();
    public PhysicsComponent actorPhysics => physics;


    [SerializeField, HideInInspector]
    private CharacterComponent character = new CharacterComponent();
    public CharacterComponent actorCharacter => character;


    [SerializeField, HideInInspector]
    private CameraComponent camComponent = new CameraComponent();
    public CameraComponent actorCamera => camComponent;


    protected override void Initialize()
    {
        base.Initialize();
        InitializeComponent(actorPhysics, actorCharacter);

        actorStateMachine.AddStates(
            State.Bind(
                State.New<PlayerLocomotionState>(),
                State.New<PlayerInteractionState>())
        );
        actorStateMachine.Run();
    }


#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject serializedObject, UnityEditor.SerializedProperty targetProperty)
    {
        base.OnInspectorGUI(editor, serializedObject, null);
        //physics.OnInspectorGUI(editor, serializedObject.FindProperty(nameof(physics)));
        character.OnInspectorGUI(editor, serializedObject.FindProperty(nameof(character)));
        camComponent.OnInspectorGUI(editor, serializedObject.FindProperty(nameof(camComponent)));
    }
#endif
}