using UnityEngine;
using Jotunn.Managers;

namespace RavenwoodRandomRelics
{
    public class HornOfThor : MonoBehaviour, Hoverable, Interactable
    {
        private Piece m_piece;

        private void Awake()
        {
            m_piece = GetComponent<Piece>();
        }

        public bool Interact(Humanoid user, bool hold, bool alt)
        {
            if (hold)
            {
                return false;
            }

            var sfx = ZNetScene.instance.GetPrefab("sfx_gjall_alerted");
            if (sfx != null)
            {
                Instantiate(sfx, transform.position + Vector3.up * 1f, Quaternion.identity);
            }

            return true;
        }

        public bool UseItem(Humanoid user, ItemDrop.ItemData item)
        {
            return false;
        }

        public string GetHoverText()
        {
            string name = m_piece != null ? m_piece.m_name : "Horn of Thor";
            return name + "\n[<color=yellow><b>E</b></color>] Blow Horn";
        }

        public string GetHoverName()
        {
            return m_piece != null ? m_piece.m_name : "Horn of Thor";
        }
    }
}