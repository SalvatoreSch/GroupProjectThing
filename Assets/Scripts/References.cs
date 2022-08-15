using System;
using UnityEngine;
using Variable;

namespace References
{
    #region Basic
    [Serializable] public class Bool : References<bool, Variable.Bool> { }
    [Serializable] public class Int : References<int, Variable.Int> { }
    
   
    [Serializable] public class Float : References<float, Variable.Float> { }
   
   
 

    #endregion

    #region Struct
    [Serializable] public class Vector2 : References<Vector2, Variable.Vector2> { }
    [Serializable] public class Vector3 : References<Vector3, Variable.Vector3> { }
    [Serializable] public class Quaternion : References<Quaternion, Variable.Quaternion> { }

    #endregion

    #region References
   
    [Serializable] public class GameObject : References<GameObject, Variable.GameObject> { }
    [Serializable] public class Transform : References<Transform, Variable.Transform> { }
  
 
    [Serializable] public class Mesh : References<Mesh, Variable.Mesh> { }
    [Serializable] public class RigidBody2D : References<RigidBody2D, Variable.RigidBody2D> { }
    [Serializable] public class Collider2D : References<Collider2D, Variable.Collider2D> { }

    #endregion

    public class References<T1, T2>
    {
        [SerializeField] public bool useConstant = true;
        [SerializeField] private T1 _constantValue;
        [SerializeField] private T1 _variable;

        public References() { }

        public References(T1 value)
        {
            useConstant = true;
            _constantValue = value;
        }

        public T1 Value
        {
            get => useConstant ? _constantValue : _variable as GenericVariable<T1>;
            set
            {
                if (useConstant)
                {
                    _constantValue = value;
                }
                else
                {
                    (_variable as GenericVariable<T1>).Value = value;
                }
            }
        }
        public static implicit operator T1(References<T1, T2> reference) => reference.Value;
    }

}