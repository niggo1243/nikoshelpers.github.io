﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace NikosAssets.Helpers
{
    public class CollectionHelper : MonoBehaviour
    {
        public static bool CollectionIsNullOrEmpty(ICollection collection)
        {
            return collection == null || collection.Count <= 0;
        }

        public static bool CollectionAndIndexChecker(ICollection collection, int i)
        {
            if (collection == null)
            {
                Debug.LogError("The given Collection is null");

                return false;
            }

            if (i < 0 || i >= collection.Count || collection.Count <= 0)
            {
                Debug.LogError("Invalid index: " + i + " or the collection is empty: " + collection.Count);

                return false;
            }

            return true;
        }

        public static T GetListItemAtIndex<T>(List<T> list, int i)
        {
            if (CollectionAndIndexChecker(list, i))
            {
                return list[i];
            }

            return default(T);
        }

        public static T GetQueueItemAtIndex<T> (Queue<T> queue, int i)
        {
            if (CollectionAndIndexChecker(queue, i))
            {
                T[] arrayT = queue.ToArray();

                return arrayT[i];
            }

            return default(T);
        }

        public static List<T> ListOfOne<T>(T item)
        {
            return new List<T> { item };
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="increment"></param>
        /// <param name="pointer"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static int PointerHandler(bool increment, int pointer, int maxLength)
        {
            if (increment && ++pointer >= maxLength)
            {
                pointer = 0;
            }
            else if (!increment && --pointer < 0)
            {
                if (maxLength - 1 < 0)
                {
                    pointer = 0;
                }
                else
                {
                    pointer = maxLength - 1;
                }
            }

            return pointer;
        }

        public static void LogCollection<T>(Collection<T> collection) where T : UnityEngine.Object
        {
            foreach (T t in collection)
            {
                Debug.Log(t);
            }
        }
    }
}
