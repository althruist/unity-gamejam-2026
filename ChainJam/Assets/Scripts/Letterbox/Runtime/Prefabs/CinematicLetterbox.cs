using UnityEngine;
using DG.Tweening;

public class CinematicLetterbox : MonoBehaviour
{
    public static CinematicLetterbox Instance { get; private set; }

    [Header("Borders")]
    public RectTransform TopBorder;
    public RectTransform BottomBorder;

    [Header("Settings")]
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Ease _easeType = Ease.OutCirc;
    [SerializeField] private bool _active = false;

    [Header("Positions (Y anchored)")]
    public float topBorderOpenPos = -50f;
    public float bottomBorderOpenPos = 50f;
    public float topBorderClosedPos = 0f;
    public float bottomBorderClosedPos = 0f;

    public bool active
    {
        get => _active;
        set
        {
            if (_active != value)
            {
                _active = value;
                AnimateBorders();
            }
        }
    }

        public float duration
    {
        get => _duration;
        set
        {
            if (_duration != value)
            {
                _duration = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (TopBorder != null)
            TopBorder.anchoredPosition = new Vector2(TopBorder.anchoredPosition.x, topBorderOpenPos);

        if (BottomBorder != null)
            BottomBorder.anchoredPosition = new Vector2(BottomBorder.anchoredPosition.x, bottomBorderOpenPos);
    }

    private void AnimateBorders()
    {
        if (TopBorder != null)
        {
            float targetY = active ? topBorderClosedPos : topBorderOpenPos;
            TopBorder.DOAnchorPosY(targetY, _duration).SetEase(_easeType);
        }

        if (BottomBorder != null)
        {
            float targetY = active ? bottomBorderClosedPos : bottomBorderOpenPos;
            BottomBorder.DOAnchorPosY(targetY, _duration).SetEase(_easeType);
        }
    }
}