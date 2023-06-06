using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TeamSleaze.Utilities
{
    public static class Helpers
    {
        private static Camera _camera;
        public static Camera MainCamera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }


        private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
        public static WaitForSeconds GetWaitForSeconds(float time)
        {
            if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

            WaitDictionary[time] = new WaitForSeconds(time);
            return WaitDictionary[time];
        }


        private static PointerEventData _eventDataCurrentPosition;
        private static List<RaycastResult> _results;
        public static bool IsOverUI()
        {
            _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            _results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
            return _results.Count > 0;
        }


        public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, MainCamera, out var result);
            return result;
        }


        public static void DeleteChildren(this Transform t)
        {
            foreach (Transform child in t) UnityEngine.Object.Destroy(child.gameObject);
        }


        public static bool Has<T>(this GameObject obj) where T : Component
        {
            return obj.GetComponent<T>() != null;
        }


        public static T Get<T>(this GameObject obj) where T : Component
        {
            return obj.GetComponent<T>();
        }

        
        public static T[] GetAll<T>(this GameObject obj) where T : Component
        {
            return obj.GetComponents<T>();
        }


        private static List<Component> componentCache = new List<Component>();
        public static bool HasComponentOrInterface<T>(this GameObject obj) where T : class
        {
            obj.GetComponents<Component>(componentCache);
            return componentCache.OfType<T>().Count() > 0;
        }

        
        public static T GetComponentOrInterface<T>(this GameObject obj) where T : class
        {
            obj.GetComponents<Component>(componentCache);
            return componentCache.OfType<T>().FirstOrDefault();
        }


        public static IEnumerable<T> GetAllComponentsOrInterfaces<T>(this GameObject obj) where T : class
        {
            return obj.GetComponents<Component>().OfType<T>();
        }

        
        public static IEnumerable<T> GetAllComponentsOrInterfacesInChildren<T>(this GameObject obj) where T : class
        {
            return obj.GetComponentsInChildren<Component>().OfType<T>();
        }

        
        public static T AddChild<T>(this GameObject parent) where T : Component
        {
            return AddChild<T>(parent, typeof(T).Name);
        }


        public static GameObject AddChild(this GameObject parent, GameObject child, bool worldPositionStays = false)
        {
            child.transform.SetParent(parent.transform, worldPositionStays);
            return parent;
        }


        public static T AddChild<T>(this GameObject parent, string name) where T : Component
        {
            var obj = AddChild(parent, name, typeof(T));
            return obj.GetComponent<T>();
        }


        /// <summary>
        /// A shortcut for creating a new game object with a number of components and adding it as a child
        /// </summary>
        /// <param name="components">A list of component types</param>
        /// <returns>The new game object</returns>
        public static GameObject AddChild(this GameObject parent, params Type[] components)
        {
            return AddChild(parent, "Game Object", components);
        }


        /// <summary>
        /// A shortcut for creating a new game object with a number of components and adding it as a child
        /// </summary>
        /// <param name="name">The name of the new game object</param>
        /// <param name="components">A list of component types</param>
        /// <returns>The new game object</returns>
        public static GameObject AddChild(this GameObject parent, string name, params Type[] components)
        {
            var obj = new GameObject(name, components);
            if (parent != null)
            {
                if (obj.transform is RectTransform) obj.transform.SetParent(parent.transform, true);
                else obj.transform.parent = parent.transform;
            }
            return obj;
        }


        /// <summary>
        /// Loads a resource and adds it as a child
        /// </summary>
        /// <param name="resourcePath">The path to the resource to load</param>
        /// <returns></returns>
        public static GameObject LoadChild(this GameObject parent, string resourcePath)
        {
            var obj = (GameObject)GameObject.Instantiate(Resources.Load(resourcePath));
            if (obj != null && parent != null)
            {
                if (obj.transform is RectTransform) obj.transform.SetParent(parent.transform, true);
                else obj.transform.parent = parent.transform;
            }
            return obj;
        }


        /// <summary>
        /// Loads a resource and adds it as a child
        /// </summary>
        /// <param name="resourcePath">The path to the resource to load</param>
        /// <returns></returns>
        public static GameObject LoadChild(this Transform parent, string resourcePath)
        {
            var obj = (GameObject)GameObject.Instantiate(Resources.Load(resourcePath));
            if (obj != null && parent != null)
            {
                if (obj.transform is RectTransform) obj.transform.SetParent(parent, true);
                else obj.transform.parent = parent;
            }
            return obj;
        }


        /// <summary>
        /// Destroys all the children of a given gameobject
        /// </summary>
        /// <param name="obj">The parent game object</param>
        public static void DestroyAllChildrenImmediately(this GameObject obj)
        {
            DestroyAllChildrenImmediately(obj.transform);
        }


        /// <summary>
        /// Destroys all the children of a given transform
        /// </summary>
        /// <param name="obj">The parent transform</param>
        public static void DestroyAllChildrenImmediately(this Transform trans)
        {
            while (trans.childCount != 0)
                GameObject.DestroyImmediate(trans.GetChild(0).gameObject);
        }


        public static uint ToUInt(this Color color)
        {
            Color32 c32 = color;
            return (uint)((c32.a << 24) | (c32.r << 16) | (c32.g << 8) | (c32.b << 0));
        }


        public static Color32 ToColor32(this uint color)
        {
            return new Color32() 
            {
                a = (byte)(color >> 24),
                r = (byte)(color >> 16),
                g = (byte)(color >> 8),
                b = (byte)(color >> 0)
            };
        }


        public static Color ToColor(this uint color)
        {
            return ToColor32(color);
        }


        public static string ToHex(this Color32 color)
        {
            return "#" + color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        }


        /// <summary>
        /// Converts a timespan to a readable format
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static string ToReadableString(this TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} hour{1}, ", span.Hours, span.Hours == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1}, ", span.Minutes, span.Minutes == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} second{1}", span.Seconds, span.Seconds == 1 ? String.Empty : "s") : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }


        /// <summary>
        /// Converts a timespan to a readable format (shorter format)
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static string ToReadableStringShortForm(this TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0}d, ", span.Days) : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0}h, ", span.Hours) : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0}m, ", span.Minutes) : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0}s", span.Seconds) : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0s";

            return formatted;
        }


        /// <summary>
        /// Randomly picks one elements from the enumerable
        /// </summary>
        /// <typeparam name="T">The type of the item</typeparam>
        /// <param name="items">The items to random from</param>
        /// <returns></returns>
        public static T RandomOne<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentException("Cannot randomly pick an item from the list, the list is null!");
            if (items.Count() == 0) throw new ArgumentException("Cannot randomly pick an item from the list, there are no items in the list!");
            var r = UnityEngine.Random.Range(0, items.Count());
            return items.ElementAt(r);
        }


        /// <summary>
        /// Randomly picks one element from the enumerable (taking into account a weight)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="weightSelector"></param>
        /// <returns></returns>
        public static T WeightedRandomOne<T>(this IEnumerable<T> sequence, Func<T, float> weightSelector)
        {
            float totalWeight = sequence.Sum(weightSelector);
            float itemWeightIndex = UnityEngine.Random.value * totalWeight;
            float currentWeightIndex = 0;

            foreach (var item in from weightedItem in sequence select new { Value = weightedItem, Weight = weightSelector(weightedItem) })
            {
                currentWeightIndex += item.Weight;
                if (currentWeightIndex >= itemWeightIndex) return item.Value;
            }

            return default(T);
        }


        /// <summary>
        /// Loops over each item in the list and logs out a particular value
        /// </summary>
        /// <typeparam name="T">The type of the item</typeparam>
        /// <param name="items">The list of items</param>
        /// <param name="objectToLog">A callback in which you will return the item to log</param>
        /// <returns>The original input list</returns>
        public static IEnumerable<T> DebugLog<T>(this IEnumerable<T> items, Func<T, object> objectToLog)
        {
            var count = 0;
            foreach (var item in items)
            {
                var obj = objectToLog(item);
                Debug.Log(String.Format("Item[{0}]: {1}", count, obj));
            }
            return items;
        }


        /// <summary>
        /// Adds a listner to a UnityEvent which is removed as soon as the event is invoked
        /// </summary>
        /// <param name="evnt">the event to listen for</param>
        /// <param name="callback">the callback to call</param>
        /// <returns></returns>
        public static UnityEvent AddOnce(this UnityEvent evnt, Action callback)
        {
            UnityAction a = null;
            a = () => {
                evnt.RemoveListener(a);
                callback();
            };

            evnt.AddListener(a);
            return evnt;
        }


        /// <summary>
        /// Adds a listner to a UnityEvent which is removed as soon as the event is invoked
        /// </summary>
        /// <param name="evnt">the event to listen for</param>
        /// <param name="callback">the callback to call</param>
        /// <returns></returns>
        public static UnityEvent<T> AddOnce<T>(this UnityEvent<T> evnt, Action<T> callback)
        {
            UnityAction<T> a = null;
            a = obj =>
            {
                evnt.RemoveListener(a);
                callback(obj);
            };

            evnt.AddListener(a);
            return evnt;
        }


        /// <summary>
        /// Shuffle list
        /// </summary>
        /// <typeparam name="T">the type of the list</typeparam>
        /// <param name="list">the list to shuffle</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        /// <summary>
        /// Takes a list, creates a copy and returns the newly shuffled list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static List<T> Randomise<T>(this List<T> inList)
        {
            var list = new List<T>(inList);
            list.Shuffle();
            return list;
        }


        /// <summary>
        /// Deactivates the gameobject this component is attached to
        /// </summary>
        /// <returns></returns>
        public static void Deactivate(this Component component)
        {
            component.gameObject.SetActive(false);
        }


        /// <summary>
        /// Activate the gameobject this component is attached to
        /// </summary>
        /// <returns></returns>
        public static void Activate(this Component component)
        {
            component.gameObject.SetActive(true);
        }


        /// <summary>
        /// Recursively looks up the tree to see if this object is parents by the supplied
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsParentedBy(this GameObject obj, GameObject parent)
        {
            if (obj.transform.parent == null)
                return false;
            if (obj.transform.parent.gameObject == parent)
                return true;

            return obj.transform.parent.gameObject.IsParentedBy(parent);
        }
    }
}