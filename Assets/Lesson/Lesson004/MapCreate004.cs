using UnityEngine;

public class MapCreate004 : MonoBehaviour
{
    public GameObject[] mapObject; // �}�b�v�p�u���b�N�I�u�W�F�N�g��Unity�G�f�B�^�ŃZ�b�g

    Vector2 mapCnt = new Vector2(50, 5); // �I�u�W�F�N�g����ׂ鐔

    // �}�b�v�ԍ��i�X�͉����z�u���Ȃ��ꏊ�j
    int[,] mapNo ={
        { 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
        { 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
        { 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
        { 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,4,1 },
        { 1,2,3,9,9,1,2,3,0,0,1,2,3,0,0,1,2,3,9,9,1,2,3,0,0,1,2,3,9,9,1,2,3,0,0,1,2,3,9,9,1,2,3,0,0,1,2,3,1,1 },
    };

    void Start()
    {
        Vector3 offset = new Vector3(-8.5f, 2.5f, 0);  // �}�b�v�̍���̃I�u�W�F�N�g���W

        // �}�b�v�̍쐬
        for (int y = 0; y < mapCnt.y; y++)
        {
            for (int x = 0; x < mapCnt.x; x++)
            {
                if (mapNo[y,x] > 8) continue; // �u���b�N�̎�ނ��W��ނ܂ő��₹��z��

                // �\������ʒu���v�Z���AmapNo�̐��l�ɍ��킹��
                // �ݒ肵���u���b�N�I�u�W�F�N�g�𐶐�����
                Vector3 pos = offset + new Vector3(x, -y, 0);
                GameObject obj = Instantiate(mapObject[mapNo[y,x]], pos, Quaternion.identity);

                // �������ꂽ�u���b�N�I�u�W�F�N�g�̐e�I�u�W�F�N�g�����̃X�N���v�g���A�^�b�`����Ă���
                // ��̃I�u�W�F�N�g�ɐݒ肵�A�q�G�����L�[�ɂł���u���b�N�I�u�W�F�N�g���܂Ƃ߂�
                obj.transform.parent = transform;
            }
        }    
    }
}
