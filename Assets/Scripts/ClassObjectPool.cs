﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test20190807 {

    public class ClassObjectPool<T> where T : class, new() {

        // 池
        public Stack<T> m_Pool = new Stack<T>();
        // 最大对象个数, <=0 表示不限个数
        protected int m_MaxCount = 0;
        // 没有回收的对象个数
        protected int m_NoRecycleCount = 0;

        public ClassObjectPool(int maxCount) {
            m_MaxCount = maxCount;
            for (int i = 0; i < maxCount; i++) {
                m_Pool.Push(new T());
            }
        }

        /// <summary>
        /// 从池里取
        /// </summary>
        /// <param name="createIfPoolEmpty"></param>
        /// <returns></returns>
        public T Spawn(bool createIfPoolEmpty) {
            if (m_Pool.Count > 0) {
                T rtn = m_Pool.Pop();
                if (rtn == null) {
                    if (createIfPoolEmpty) {
                        rtn = new T();
                    }
                }
                m_NoRecycleCount++;
                return rtn;
            } else {
                if (createIfPoolEmpty) {
                    T rtn = new T();
                    m_NoRecycleCount++;
                    return rtn;
                }
            }

            return null;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Recycle(T obj) {
            if (obj == null) {
                return false;
            }

            m_NoRecycleCount--;
            if (m_Pool.Count >= m_MaxCount && m_MaxCount > 0) {
                obj = null;
                return false;
            }

            m_Pool.Push(obj);
            return true;
        }
    }

}