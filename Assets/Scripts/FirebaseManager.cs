using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseManager
{
    public AuthManager AuthManager;
    public UnityAction OnInitialized;
    

    public void Initialize()
    {
        AuthManager = new AuthManager();
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                AuthManager.Initialize();
                OnInitialized?.Invoke();
                Debug.Log("Firebase dependencies are available");
            }
            else
            {
                Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
        
    }
    
    
}