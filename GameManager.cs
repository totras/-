using UnityEngine;//Instantiate��GetComponent�Ȃǂ̊֐��𗘗p�ł���悤�ɂ��郉�C�u����

public class GameManager : MonoBehaviour
{
    //1)�f�ފ֘A
    public GameObject cardPrefab;//Card�v���n�u
    public Sprite backImage;//����
    public Sprite frontImage;//�\��

    //2)�J�[�h�����������߂̏���
    private SpriteRenderer sr;//�摜�\���Ɋւ���
    private BoxCollider2D col;//�����蔻��Ɋւ���
    private bool isFront = false;//false=���Atrue=�\

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //3)�J�[�h�����擾���ė������ɃZ�b�g(Instantiate�Ő���)
        //Instantiate(����, �ʒu, ��]); 
        //GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);//Vector3.zero�Ńx�N�g��3����(x,y,z)��0,Quaternion.identity�ŉ�]�Ȃ�
        GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        sr = newCard.GetComponent<SpriteRenderer>();//�J�[�h�̉摜�����擾
        col = newCard.GetComponent<BoxCollider2D>();//�J�[�h�̓����蔻����擾
        ShowBack();//�ŏ��͗��ɃZ�b�g�����g��4)��
    }

    // Update is called once per frame
    void Update()
    {
        //���N���b�N������(0�͍�,1�͉E)
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X�N���b�N�ʒu���擾
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mp.z = 0;

            //�}�E�X�̈ʒu(mp)��Collider�͈̔͂�������
            if (col.OverlapPoint(mp))
            {
                if (isFront)
                {
                    ShowBack();//�\�����Ȃ痠������
                }
                else
                {
                    ShowFront();//�����łȂ���Ε\������
                }
            }
        }

    }

    //�R���p�C������錾��͊֐����g�p����ӏ��̉��Ő錾���Ă�OK�i���������シ��j
    //Showback()�̒��g/�������ɃZ�b�g
    void ShowBack()
    {
        sr.sprite = backImage;
        isFront = false;//���A�������ł���Ƃ�������ێ�
    }

    //5)�\�����ɃZ�b�g
    void ShowFront()
    {
        sr.sprite = frontImage;
        isFront = true;//���A�\�����ł���Ƃ�������ێ�
    }
}
