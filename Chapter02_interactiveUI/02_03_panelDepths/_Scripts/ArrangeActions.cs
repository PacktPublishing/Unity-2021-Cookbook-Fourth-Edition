using UnityEngine;

public class ArrangeActions : MonoBehaviour
{
	private RectTransform panelRectTransform;

	void Awake()
	{
        // cache reference to parent Rect Transform
		panelRectTransform = GetComponent<RectTransform>();
	}

	//------------------------------
	// we change the 'SiblingIndex' of the parent GameObject to be one LESS
	// so it is drawn sooner, and so 'below' the next UI object to be drawn
	public void MoveDownOne()
	{
		print ("(before change) " + gameObject.name +  " sibling index = " + panelRectTransform.GetSiblingIndex());

		int currentSiblingIndex = panelRectTransform.GetSiblingIndex();
		panelRectTransform.SetSiblingIndex( currentSiblingIndex - 1 );

		print ("(after change) " + gameObject.name +  " sibling index = " + panelRectTransform.GetSiblingIndex());
	}
	
	//------------------------------
	// we change the 'SiblingIndex' of the parent GameObject to be one MORE
	// so it is drawn later, and so 'above' the next UI object to be drawn
	public void MoveUpOne()
	{
		print ("(before change) " + gameObject.name +  " sibling index = " + panelRectTransform.GetSiblingIndex());
		
		int currentSiblingIndex = panelRectTransform.GetSiblingIndex();
		panelRectTransform.SetSiblingIndex( currentSiblingIndex + 1 );
		
		print ("(after change) " + gameObject.name +  " sibling index = " + panelRectTransform.GetSiblingIndex());
	}
}